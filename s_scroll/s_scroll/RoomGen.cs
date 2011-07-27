using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace r_like
{
    class RoomGen
    {
        //string line;
        string[] file;
        struct wall_positions
        {
            public int X;
            public int Y;
            public int TYPE;
        }
        List<wall_positions> room_type;

        public void Initialize()
        {
            file = System.IO.File.ReadAllLines("gen_data\rooms.txt");
            bool reading_room_in = false;
            string line;

            for (int i = 0; i < file.Length; i++)
            {
                if(file[i].StartsWith("-") && !reading_room_in)
                    reading_room_in = true;

                if (reading_room_in)
                {
                    line = file[i];
                    wall_positions[] temp;

                    if (line.IndexOf('-') != -1)
                    {
                        int lower_bound = Convert.ToInt32(line.Substring(0, line.IndexOf('-')));
                        int upper_bound = Convert.ToInt32(line.Substring(line.IndexOf('-'), line.IndexOf(',') - line.IndexOf('-')));
                        
                        int count = 0;
                        int y = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',')), line.IndexOf(',', line.IndexOf(',')) - line.IndexOf(',')));
                        temp = new wall_positions[upper_bound];
                        int type = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',', line.IndexOf(',')))));
                        for (int j = lower_bound; j < upper_bound; j++){
                            temp[count].X = j;
                            temp[count].Y = y;
                            temp[count].TYPE = type;
                            room_type.Add(temp[count]);
                            count++;
                        }
                    }
                    if (line.IndexOf('-', line.IndexOf(',')) != -1)
                    {
                        int lower_bound = Convert.ToInt32(line.Substring(line.IndexOf(',') + 1, line.IndexOf('-')));
                        int upper_bound = Convert.ToInt32(line.Substring(line.IndexOf('-', line.IndexOf(',')), line.IndexOf(',') - line.IndexOf('-', line.IndexOf(','))));

                        int count = 0;
                        int x = Convert.ToInt32(line.Substring(0, line.IndexOf(',')));
                        temp = new wall_positions[upper_bound];
                        int type = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',', line.IndexOf(',')))));
                        for (int j = lower_bound; j < upper_bound; j++)
                        {
                            temp[count].X = x;
                            temp[count].Y = j;
                            temp[count].TYPE = type;
                            count++;
                        }
                        room_type.Add(temp[count]);
                    }
                    else
                    {
                        wall_positions t;
                        t.X = Convert.ToInt32(line.Substring(0, line.IndexOf(',')));
                        t.Y = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',')), line.IndexOf(',', line.IndexOf(',')) - line.IndexOf(',')));
                        t.TYPE = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',', line.IndexOf(',')))));
                        room_type.Add(t);
                    }

                }

            }
        }

    }
}
