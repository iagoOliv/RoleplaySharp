using System;

namespace src
{
    public sealed class Item
    {
        public string Type { get; }
        public int Value { get; }

        public Item(string type, int value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}