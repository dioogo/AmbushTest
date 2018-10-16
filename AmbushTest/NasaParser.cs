using AmbushTest.Commands;
using AmbushTest.Directions;
using AmbushTest.Factories;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Windows;

namespace AmbushTest
{
    public class NasaParser
    {
        private IFileSystem fileSystem;

        public NasaParser() { }

        public NasaParser(IFileSystem _fileSystem)
        {
            fileSystem = _fileSystem;
        }

        public virtual List<Rover> ReadFile()
        {
            var rovers = new List<Rover>();

            string[] allText = fileSystem.File.ReadAllLines(@"C:\Temp\AmbushTest.txt");

            if (allText.Any())
            {
                var plateauSize = GetPlateauSize(allText[0]);
                Plateau plateau = new Plateau(plateauSize);

                for (int i = 1; i < allText.Length - 1; i += 2)
                {
                    string[] firstLine = allText[i].Split(' ');

                    Point roverPosition = new Point(Convert.ToDouble(firstLine[0]), Convert.ToDouble(firstLine[1]));

                    IDirection roverDirection = GetDirection(firstLine[2]);

                    List<ICommand> commands = GetCommands(allText[i + 1]);

                    rovers.Add(new Rover(roverPosition, roverDirection, plateau, commands));
                }
            }

            return rovers;
        }

        private List<ICommand> GetCommands(string commandLine)
        {
            List<ICommand> commands = new List<ICommand>();
            for (int j = 0; j < commandLine.Length; j++)
            {
                commands.Add(CommandFactory.CreateCommand(commandLine[j]));
            }
            return commands;
        }

        private IDirection GetDirection(string direction)
        {
            IDirection roverDirection = DirectionFactory.CreateDirection(direction[0]);
            
            return roverDirection;
        }

        private Point GetPlateauSize(string firsLine)
        {
            string[] plateauSizePoint = firsLine.Split(' ');
            var plateauSize = new Point(Convert.ToDouble(plateauSizePoint[0]), Convert.ToDouble(plateauSizePoint[1]));
            return plateauSize;
        }
    }
}
