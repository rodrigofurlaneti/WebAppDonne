﻿namespace WebApi.Donne.Infrastructure.SeedWork
{
    public interface ILogger
    {
        void Trace(string message);
        void TraceExeption(string message);
    }
}