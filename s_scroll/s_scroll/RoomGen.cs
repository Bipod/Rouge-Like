using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace r_like
{
    class RoomGen
    {
        string[] file;
        public struct wall_positions
        {
            public int X;
            public int Y;
            public int TYPE;
        }
        List<wall_positions> room_type = new List<wall_positions>();

        public void Initialize()
        {
            file = System.IO.File.ReadAllLines("gen_data/rooms.txt");
            bool reading_room_in = false;
            string line;

            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].StartsWith(":") && !reading_room_in)
                    reading_room_in = true;

                else if (reading_room_in)
                {
                    if (file[i].StartsWith(":"))
                        break;

                    line = file[i];
                    wall_positions[] temp;

                    //if the x is a spread
                    if (!line.StartsWith("//") && !line.StartsWith(":") &&
                        line.IndexOf(',') > line.IndexOf('-') && line.IndexOf('-') != -1)
                    {
                        int lower_bound = Convert.ToInt32(line.Substring(0, line.IndexOf('-')));
                        int upper_bound = Convert.ToInt32(line.Substring(line.IndexOf('-') + 1, line.IndexOf(',', line.IndexOf('-')) - line.IndexOf('-') - 1)) + 1;

                        int count = 0;
                        int y = Convert.ToInt32(line.Substring(line.IndexOf(',') + 1, line.IndexOf(',', line.IndexOf(',') + 1) - line.IndexOf(',') - 1));
                        temp = new wall_positions[upper_bound];
                        int type = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',') + 1) + 1));
                        for (int j = lower_bound; j < upper_bound; j++)
                        {
                            temp[count].X = j;
                            temp[count].Y = y;
                            temp[count].TYPE = type;
                            room_type.Add(temp[count]);
                            count++;
                        }
                    }
                    //if the y is a spread
                    if (!line.StartsWith("//") && !line.StartsWith(":") &&
                        line.IndexOf('-') > line.IndexOf(',') && line.IndexOf('-') != -1)
                    {
                        int lower_bound = Convert.ToInt32(line.Substring(line.IndexOf(',') + 1, line.IndexOf('-') - line.IndexOf(',') - 1));
                        int upper_bound = Convert.ToInt32(line.Substring(line.IndexOf('-') + 1, line.IndexOf(',', line.IndexOf('-')) - line.IndexOf('-') - 1)) + 1;

                        int count = 0;
                        int x = Convert.ToInt32(line.Substring(0, line.IndexOf(',')));
                        temp = new wall_positions[upper_bound];
                        int type = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',') + 1) + 1));
                        for (int j = lower_bound; j < upper_bound; j++)
                        {
                            temp[count].X = x;
                            temp[count].Y = j;
                            temp[count].TYPE = type;
                            room_type.Add(temp[count]);
                            count++;
                        }
                    }
                    else if (!line.StartsWith("//") && !line.StartsWith(":") && line.IndexOf('-') == -1)
                    {
                        wall_positions t;
                        t.X = Convert.ToInt32(line.Substring(0, line.IndexOf(',')));
                        t.Y = Convert.ToInt32(line.Substring(line.IndexOf(',') + 1, line.IndexOf(',', line.IndexOf(',') + 1) - line.IndexOf(',') - 1));
                        t.TYPE = Convert.ToInt32(line.Substring(line.IndexOf(',', line.IndexOf(',') + 1) + 1));
                        room_type.Add(t);
                    }
                }
            }
        } //Initialize()

        public wall_positions GetWallPositions(int index)
        {
            return room_type[index];
        }
        public int GetRoomTypesSize()
        {
            return room_type.Count;
        }
    }
}
