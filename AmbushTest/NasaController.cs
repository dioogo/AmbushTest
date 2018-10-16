using System.Collections.Generic;

namespace AmbushTest
{
    public class NasaController
    {
        private NasaParser nasaParser;

        public NasaController(NasaParser _nasaParser)
        {
            nasaParser = _nasaParser;
        }

        public List<Rover> Execute()
        {
            var rovers = nasaParser.ReadFile();

            foreach (var rover in rovers)
            {
                foreach (var command in rover.Commands)
                {
                    command.Execute(rover);
                }
            }
            return rovers;
        }
    }
}
