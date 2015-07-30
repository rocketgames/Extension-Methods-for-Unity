using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

/* *****************************************************************************
 * File:    ExceptionExtensions.cs
 * Author:  Philip Pierce - Thursday, October 09, 2014
 * Description:
 *  Exception extensions
 *  
 * History:
 *  Thursday, October 09, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Exception extensions
/// </summary>
public static class ExceptionExtensions
{
    #region Constants

    private const string tab = "   ";
    private const string nl = "\r\n";

    // Constants
    #endregion

    #region ToLogString

    public static string ToLogString(this Exception excep, StackFrame stackFrame, object AdditionalInfo)
    {
        StringBuilder sb = new StringBuilder();

#if (! UNITY_IPHONE)
        // stack frame info
        MethodBase methodBase = stackFrame.GetMethod();

        sb.AppendFormat("Exception Location:{0}", nl);
        sb.AppendFormat("{0}Namespace: {1}{2}", tab, methodBase.ReflectedType.Namespace, nl);
        sb.AppendFormat("{0}Class Name: {1}{2}", tab, methodBase.ReflectedType.Name, nl);
        sb.AppendFormat("{0}Method Name: {1}{2}", tab, methodBase.Name, nl);
#endif

        // build the exception info string
        sb.AppendFormat("Exception Information:{0}", nl);
        sb.AppendFormat("{2}Message: {0}{1}", excep.Message, nl, tab);
        sb.AppendFormat("{2}Source: {0}{1}{1}", excep.Source, nl, tab);
        sb.AppendFormat("Stack Trace: {1} {0}{1}{1}", excep.StackTrace, nl);

        // inner exception
        if (excep.InnerException != null)
        {
            sb.AppendFormat("{1}{0}Inner Exception Info:{0}", nl, tab);
            sb.AppendFormat("{2}{2}Message: {0}{1}", excep.InnerException.Message, nl, tab);
            sb.AppendFormat("{2}{2}Source: {0}{1}", excep.InnerException.Source, nl, tab);
            sb.AppendFormat("{2}{2}Stack Trace: {0}{1}", excep.InnerException.StackTrace, nl, tab);
        }

        // additional info
        if (AdditionalInfo != null)
        {
            sb.AppendFormat("Additional Object Info{0}", nl);
#if (! UNITY_IPHONE)
            sb.AppendFormat("{0}{1}{2}", tab, ObjectDumper.GetObjectValue(AdditionalInfo), nl);
#else
            sb.AppendFormat("{0}{1}{2}", tab, AdditionalInfo.ToString(), nl);
#endif
        }

        // device info
        sb.AppendFormat("Device Info:{0}", nl);
        sb.AppendFormat("{2}Device OS: {0} {1}", SystemInfo.operatingSystem, nl, tab);
        sb.AppendFormat("{2}Device Model: {0} {1}", SystemInfo.deviceModel, nl, tab);
        sb.AppendFormat("{2}Device Type: {0} {1}", SystemInfo.deviceType, nl, tab);
        sb.AppendFormat("{2}Device Name: {0} {1}", SystemInfo.deviceName, nl, tab);
        sb.AppendFormat("{2}Device ID: {0} {1}", SystemInfo.deviceUniqueIdentifier, nl, tab);
        sb.AppendFormat("{2}Device Memory: {0} {1}", SystemInfo.systemMemorySize, nl, tab);

        return sb.ToString();
    }

    // ToLogString
    #endregion
}

public class ObjectDumper
{
#if (! UNITY_IPHONE)
    public static void Write(object o)
    {
        Write(o, 0);
    }

    public static void Write(object o, int depth)
    {
        ObjectDumper dumper = new ObjectDumper(depth);
        dumper.WriteObject(null, o);
    }

    public static string GetObjectValue(object o)
    {
        ObjectDumper dumper = new ObjectDumper(1, false);
        dumper.WriteObject(null, o);
        return dumper.sb.ToString();
    }

    private StringBuilder sb = new StringBuilder();
    private TextWriter writer;
    private int pos;
    private int level;
    private int depth;

    private ObjectDumper(int depth)
    {
        this.writer = Console.Out;
        this.depth = depth;
    }

    private ObjectDumper(int depth, bool ConsoleOut)
    {
        if (ConsoleOut)
            this.writer = Console.Out;
        this.depth = depth;
    }

    private void WriterWrite(string s)
    {
        if (writer != null)
            writer.Write(s);
        sb.Append(s);
    }

    private void Write(string s)
    {
        if (s != null)
        {
            WriterWrite(s);
            pos += s.Length;
        }
    }

    private void WriteIndent()
    {
        for (int i = 0; i < level; i++)
        {
            WriterWrite("  ");
        }
    }

    private void WriteLine()
    {
        if (writer != null)
            writer.WriteLine();
        sb.Append("\r\n");
        pos = 0;
    }

    private void WriteTab()
    {
        WriterWrite("  ");
        while (pos % 8 != 0)
            Write(" ");
    }

    private void WriteObject(string prefix, object o)
    {
        try
        {
            if (o == null || o is ValueType || o is string || o is XElement)
            {
                WriteIndent();
                Write(prefix);
                WriteValue(o);
                WriteLine();
            }
            else if (o is IEnumerable)
            {
                foreach (object element in (IEnumerable)o)
                {
                    try
                    {
                        if (element is IEnumerable && !(element is string))
                        {
                            WriteIndent();
                            Write(prefix);
                            Write("...");
                            WriteLine();
                            if (level < depth)
                            {
                                level++;
                                WriteObject(prefix, element);
                                level--;
                            }
                        }
                        else
                        {
                            WriteObject(prefix, element);
                        }
                    }

                    catch (Exception)
                    {
                        // eat the exception ??
                    }
                }
            }
            else
            {
                MemberInfo[] members = o.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                WriteIndent();
                Write(prefix);
                bool propWritten = false;
                foreach (MemberInfo m in members)
                {
                    try
                    {
                        FieldInfo f = m as FieldInfo;
                        PropertyInfo p = m as PropertyInfo;
                        if (f != null || p != null)
                        {
                            if (propWritten)
                            {
                                WriteTab();
                            }
                            else
                            {
                                propWritten = true;
                            }
                            Write(m.Name);
                            Write("=");
                            Type t = f != null ? f.FieldType : p.PropertyType;
                            if (t.IsValueType || t == typeof(string))
                            {
                                WriteValue(f != null ? f.GetValue(o) : p.GetValue(o, null));
                            }
                            else
                            {
                                if (typeof(IEnumerable).IsAssignableFrom(t))
                                {
                                    Write("...");
                                }
                                else
                                {
                                    Write("{ }");
                                }
                            }
                            WriteLine();
                        }
                    }

                    catch (Exception)
                    {
                        // eat the exception ??
                    }
                }
                if (propWritten)
                    WriteLine();
                if (level < depth)
                {
                    foreach (MemberInfo m in members)
                    {
                        try
                        {
                            FieldInfo f = m as FieldInfo;
                            PropertyInfo p = m as PropertyInfo;
                            if (f != null || p != null)
                            {
                                Type t = f != null ? f.FieldType : p.PropertyType;
                                if (!(t.IsValueType || t == typeof(string)))
                                {
                                    object value = f != null ? f.GetValue(o) : p.GetValue(o, null);
                                    if (value != null)
                                    {
                                        level++;
                                        WriteObject(m.Name + ": ", value);
                                        level--;
                                    }
                                }
                            }
                        }

                        catch (Exception)
                        {
                            // eat the exception ??
                        }
                    }
                }
            }
        }

        catch (Exception)
        {
            // eat the exception??
        }
    }

    private void WriteValue(object o)
    {
        if (o == null)
        {
            Write("null");
        }
        else if (o is DateTime)
        {
            Write(((DateTime)o).ToShortDateString());
        }
        else if (o is ValueType || o is string || o is XElement)
        {
            Write(o.ToString());
        }
        else if (o is IEnumerable)
        {
            Write("...");
        }
        else
        {
            Write("{ }");
        }
    }
#else
        public static string GetObjectValue(object o)
        {
            return o.ToString();
        }

#endif
}
