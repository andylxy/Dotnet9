﻿namespace Dotnet9.Application.Contracts;

public class EntityDto
{
    public int Id { get; set; }

    public override string ToString()
    {
        return $"[DTO: {GetType().Name}] Id = {Id}";
    }
}