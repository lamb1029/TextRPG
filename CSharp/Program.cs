using System;

namespace CSharp
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        static ClassType Class = ClassType.None;
        struct Player
        {
            public int hp, attack;
        }
        enum MonsterType
        {
            Slime = 0,
            Orc = 1,
            Skeleton = 2
        }
        struct Monster
        {
            public int hp, attack;
        }

        static void Main(string[] args)
        {
            while(true)
            {
                ClassChoice();
                if(Class != ClassType.None)
                {
                    Player player;
                    PlayerStates(Class, out player);
                    EnterGame(ref player);
                }
            }
        }

        //직업선택
        static ClassType ClassChoice()
        {
            //while(Class == ClassType.None)
            //{
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("[1] 기사");
                Console.WriteLine("[2] 궁수");
                Console.WriteLine("[3] 법사");

                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        Class = ClassType.Knight;
                        Console.WriteLine($"당신의 직업은 기사입니다.");
                        break;
                    case "2":
                        Class = ClassType.Archer;
                        Console.WriteLine($"당신의 직업은 궁수입니다.");
                        break;
                    case "3":
                        Class = ClassType.Mage;
                        Console.WriteLine($"당신의 직업은 법사입니다.");
                        break;
                }
            //}
            return Class;
        }

        //직업에 따른 능력치
        static void PlayerStates(ClassType a, out Player player)
        {
            player.hp = 10;
            player.attack = 1;
            //기사(100/10)궁사(75/15)법사(50/20)
            switch(a)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 15;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 20;
                    break;
            }
            Console.WriteLine($"HP : {player.hp}, Attack : {player.attack}");

        }

        static void EnterGame(ref Player states)
        {
            while(true)
            {
                Console.WriteLine("마을에 들어왔습니다!");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();
                if(input == "1")
                {
                    EnterField(ref states);
                }
                else if(input == "2")
                {
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("필드로 나왔습니다.");
                //몬스터 생성
                Monster monster;
                //랜덤으로 1~3 몬스터 중 하나 조우
                SpawnMonster(out monster);
                Console.WriteLine("[1] 전투 들어가기");
                Console.WriteLine("[2] 마을로 도망가기");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if(input == "2")
                {
                    //33%
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("마을로 도망쳤습니다!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다!");
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        private static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                //플레이어가 몬스터 공격
                monster.hp -= player.attack;
                //몬스터 피가 0이라면 승리
                if(monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력은 {player.hp}입니다!");
                    break;
                }
                //몬스터 피가 0이 아니라면 반격
                player.hp -= monster.attack;
                if(player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다!");
                    break;
                }

            }
        }

        private static void SpawnMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(0, 3);
            switch(randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 나타났습니다.");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 나타났습니다.");
                    monster.hp = 50;
                    monster.attack = 5;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 나타났습니다.");
                    monster.hp = 25;
                    monster.attack = 10;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
    }
}
