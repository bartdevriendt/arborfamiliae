﻿using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class Place : BaseModel, IAggregateRoot, IHasSequence
{
    public string ArborId { get; set; }
    public string SequenceType => "Place";

    public void SetSequence(int sequence)
    {
        ArborId = $"P{sequence:0000}";
    }
}