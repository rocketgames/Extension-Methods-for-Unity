using System;
using System.Threading;

/// <summary>
/// Provides extensions for the ReaderWriterLockSlim to make it easier to ensure the lock is released
/// </summary>
public static class ReadWriteLockSlimExtend
{
    public static void PerformUsingReadLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
    {
        try
        {
            readerWriterLockSlim.EnterReadLock();
            action();
        }
        finally
        {
            readerWriterLockSlim.ExitReadLock();
        }
    }

    public static T PerformUsingReadLock <T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
    {
        try
        {
            readerWriterLockSlim.EnterReadLock();
            return action();
        }
        finally
        {
            readerWriterLockSlim.ExitReadLock();
        }
    }

    public static void PerformUsingWriteLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
    {
        try
        {
            readerWriterLockSlim.EnterWriteLock();
            action();
        }
        finally
        {
            readerWriterLockSlim.ExitWriteLock();
        }
    }

    public static T PerformUsingWriteLock <T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
    {
        try
        {
            readerWriterLockSlim.EnterWriteLock();
            return action();
        }
        finally
        {
            readerWriterLockSlim.ExitWriteLock();
        }
    }

    public static void PerformUsingUpgradeableReadLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
    {
        try
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            action();
        }
        finally
        {
            readerWriterLockSlim.ExitUpgradeableReadLock();
        }
    }

    public static T PerformUsingUpgradeableReadLock <T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
    {
        try
        {
            readerWriterLockSlim.EnterUpgradeableReadLock();
            return action();
        }
        finally
        {
            readerWriterLockSlim.ExitUpgradeableReadLock();
        }
    }
}