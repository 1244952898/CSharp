namespace IOCTest.Cat
{
    internal class Key : IEquatable<Key>
    {
        public ServiceRegistry Registry { get; set; }
        public Type[] GenericArguments { get; set; }

        public Key(ServiceRegistry registry, Type[] genericArguments)
        {
            Registry = registry;
            GenericArguments = genericArguments;
        }

        public bool Equals(Key other)
        {
            if (Registry != other.Registry)
            {
                return false;
            }
            if (GenericArguments.Length != other.GenericArguments.Length)
            {
                return false;
            }

            for (int i = 0; i < GenericArguments.Length; i++)
            {
                if (GenericArguments[i] != other.GenericArguments[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = Registry.GetHashCode();
            for (int i = 0; i < GenericArguments.Length; i++)
            {
                hashCode ^= GenericArguments[i].GetHashCode();
            }
            return hashCode;
        }

        public override bool Equals(object obj) => obj is Key other && Equals(other);
    }
}
