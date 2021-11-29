using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();
        private bool isEscapeFail = false;
        int damage;
        private string monsterName;

        public void Process()
        {
            switch(mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }


        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }
        private void ProcessField()
        {
            Console.WriteLine("필드로 나왔습니다.");

            CreateRandomMonster();

            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 마을로 도망가기");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    ProcessEscape();
                    break;
            }
        }

        private void ProcessFight()
        {
            while (true)
            {
                //도망실패시 몬스터가 선공
                if(isEscapeFail == true)
                {
                    MonsterAttack();
                    if (player.IsDead())
                    {
                        Console.WriteLine("죽었습니다!");
                        mode = GameMode.Lobby;
                        break;
                    }
                    isEscapeFail = false;
                }

                PlayerAttack();
                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력 : {player.GetHP()}");
                    break;
                }

                MonsterAttack();
                if (player.IsDead())
                {
                    Console.WriteLine("죽었습니다!");
                    mode = GameMode.Lobby;
                    break;
                }



            }
        }
        void PlayerAttack()
        {
            damage = player.GetAttack();
            monster.OnDamaged(damage);
            Console.WriteLine($"{monsterName}에게 {damage}의 피해를 입혔습니다.");
        }
        void MonsterAttack()
        {
            damage = monster.GetAttack();
            player.OnDamaged(damage);
            Console.WriteLine($"{monsterName}에게 {damage}의 피해를 입었습니다.");
        }
        private void ProcessEscape()
        {
            //33%활률로 도망
            int randValue = rand.Next(0, 100);
            if(randValue < 33)
            {
                Console.WriteLine("무사히 마을로 도망쳤습니다.");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("도망치는데 실패했습니다. 몬스터가 당신에게 달려듭니다.");
                isEscapeFail = true;
                ProcessFight();
            }
        }
        private void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);
            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    monsterName = "슬라임";
                    Console.WriteLine("슬라임이 나타났습니다!");
                    break;
                case 1:
                    monster = new Orc();
                    monsterName = "오크";
                    Console.WriteLine("오크가 나타났습니다!");
                    break;
                case 2:
                    monster = new Skeleton();
                    monsterName = "스켈레톤";
                    Console.WriteLine("스켈레톤이 나타났습니다!");
                    break;
            }
        }
    }
}
