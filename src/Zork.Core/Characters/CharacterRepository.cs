﻿using System.Collections.Generic;

namespace Zork.Core.Characters
{
    public class CharacterRepository : ICharacterRepository
    {
        private static readonly Dictionary<string, Character> users;

        static CharacterRepository()
        {
            users = new Dictionary<string, Character>();
        }

        public void Add(string userName, Character character)
        {
            users[userName] = character;
        }

        public Character GetCharacterOf(string userName)
        {
            return users.ContainsKey(userName) ? users[userName] : null;
        }
    }
}