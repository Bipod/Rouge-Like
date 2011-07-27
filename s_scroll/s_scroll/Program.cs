using System;

namespace r_like
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (r_like game = new r_like())
            {
                game.Run();
            }
        }
    }
#endif
}

