using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }
    class Monster : Creature
    {
        protected MonsterType type = MonsterType.None;

        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            this.type = type;
        }

        public MonsterType GetMonsterType() { return type; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            Setinfo(10, 1);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            Setinfo(30, 2);
        }
    } 

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            Setinfo(15, 5);
        }
    }
}
