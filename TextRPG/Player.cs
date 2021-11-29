using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    enum PlayerType
    {
        None,
        Knight,
        Archer,
        Mage
    }
    class Player
    {
        protected PlayerType type = PlayerType.None;
        protected int hp = 0, attack = 0;

        protected Player(PlayerType type)
        {
            this.type = type;
        }
        public void Setinfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public int GetHP() { return hp; }
        public int GetAttack() { return attack; }
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            Setinfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            Setinfo(75, 15);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            Setinfo(50, 20);
        }
    }
}
