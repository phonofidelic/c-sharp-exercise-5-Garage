using System;

namespace Garage;

public interface IHandler
{
    void Handle(Request request);
}

public abstract class Request
{
    
}