﻿namespace Hexagonal_FullProject.Domain.ValueObjects
{
    public class NameShouldNotBeEmptyException : DomainException
    {
        internal NameShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
