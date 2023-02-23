// See https://aka.ms/new-console-template for more information
using SpinLockDemo;

Console.WriteLine("Hello, World!");
var sslock = new SimpleSpinLock();

sslock.Enter();
Console.WriteLine("执行");
Thread.Sleep(3000);
var sl = new SpinLock();
sslock.Leave();

