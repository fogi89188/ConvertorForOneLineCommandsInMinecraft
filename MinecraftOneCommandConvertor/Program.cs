using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftOneCommandConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "y";
            int count = 0;
            StringBuilder sb = new StringBuilder();
            while (command == "y")
            {
                Console.Clear();
                command = GetCommand(count, sb);
                Console.WriteLine(sb.ToString());
                Console.WriteLine();
                Console.WriteLine("Go again? Y/N");
                command = Console.ReadLine();
            }
            return;
        }

        private static string GetCommand(int count, StringBuilder sb)
        {
            sb.Clear();
            string command;
            sb.Append("/summon falling_block ~ ~1 ~ {Time:1, DropItem:0, BlockState: {Name: \"command_block\"} ,TileEntityData:{Command:");

            command = Console.ReadLine();
            while (command != "end")
            {
                count++;
                if (count == 1)
                {
                    sb.Append($"\"{command}\"");
                    sb.Append(", auto:1}");
                }
                else
                {
                    sb.Append(", Passengers:[{id:\"minecraft:falling_block\", Time:1, DropItem:0, BlockState:{Name:\"command_block\"}, TileEntityData:{auto:1, Command:");
                    sb.Append($"\"{command}\"");
                    sb.Append("}");
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < count - 1; i++)
            {
                sb.Append("}]");
            }
            sb.Append("}");
            return command;
        }
    }
}
