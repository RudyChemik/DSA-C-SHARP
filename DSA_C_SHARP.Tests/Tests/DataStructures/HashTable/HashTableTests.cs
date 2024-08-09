using DSA_C_SHARP.DataStructures.HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.Tests.Tests.DataStructures.HashTable
{
    public class HashTableTests
    {
        private HashTable<string, int> hashTable;

        [SetUp]
        public void Setup()
        {
            hashTable = new HashTable<string, int>();
        }

        [Test]
        public void AddAndRetrieveValue()
        {
            hashTable.Add("key1", 1);
            bool res = hashTable.TryGetValue("key1", out int value);

            Assert.That(res, Is.True);
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void RemoveValue()
        {
            hashTable.Add("key1", 1);
            bool removed = hashTable.Remove("key1");
            bool res = hashTable.TryGetValue("key1", out int value);

            Assert.That(removed, Is.True);
            Assert.That(res, Is.False);
        }

        [Test]
        public void HandleCollisions()
        {
            var smallHashTable = new HashTable<int, string>(2);
            smallHashTable.Add(1, "value1");
            smallHashTable.Add(3, "value2");

            bool res1 = smallHashTable.TryGetValue(1, out string value1);
            bool res2 = smallHashTable.TryGetValue(3, out string value2);

            Assert.That(res1, Is.True);
            Assert.That(value1, Is.EqualTo("value1"));

            Assert.That(res2, Is.True);
            Assert.That(value2, Is.EqualTo("value2"));
        }

        [Test]
        public void ResizeHashTable()
        {
            for (int i = 0; i < 10; i++)
            {
                hashTable.Add($"key{i}", i);
            }

            bool res = hashTable.TryGetValue("key9", out int value);

            Assert.That(res, Is.True);
            Assert.That(value, Is.EqualTo(9));
        }

        [Test]
        public void AddDuplicateKeyThrowsException()
        {
            hashTable.Add("key1", 1);
            Assert.Throws<ArgumentException>(() => hashTable.Add("key1", 2));
        }

        [Test]
        public void InitializeWithInvalidCapacityThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HashTable<string, int>(0));
        }

        [Test]
        public void InitializeWithInvalidLoadFactorThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HashTable<string, int>(8, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new HashTable<string, int>(8, 1.1f));
        }
    }
}

