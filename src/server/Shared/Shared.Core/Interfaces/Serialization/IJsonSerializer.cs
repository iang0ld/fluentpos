﻿namespace FluentPOS.Shared.Core.Interfaces.Serialization
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj, IJsonSerializerSettingsOptions settings = null);

        T Deserialize<T>(string text, IJsonSerializerSettingsOptions settings = null);
    }
}