using System;
using Furion.Xunit;
using Xunit;
using Xunit.Abstractions;

[assembly:TestFramework("MyTemplate.xUnitTest.TestProgram","MyTemplate.xUnitTest")]
namespace MyTemplate.xUnitTest;


public class TestProgram:TestStartup
{
    public TestProgram(IMessageSink messageSink) : base(messageSink)
    {
        Serve.Run(silence: true);
    }
}