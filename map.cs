using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBF_Testing
{
    class Map
    {
        public List<List<Node>> nodes = new List<List<Node>>();
        public int width;
        public int height;
        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            foreach(var x in nodes)
            {
                List<Node> columnlist = new List<Node>();
                foreach (var y in x)
                {
                    columnlist.Add(new Node());
                }
                nodes.Add(columnlist);
            }
        
        }
        void Pathfind()
        {
            int currentX = 0;
            int currentY = 0;

            // Contains coordinates of every node we are search. Contains the x/y coordinates and distance travelled.
            List<List<int>> coords = new List<List<int>>();

            // Search for the starting node and set the first coordinates to that node
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    if (nodes[x][y].type == 1)
                    {
                        coords.Add(new List<int>(new int[] { x, y, 1 }));
                        nodes[x][y].distance = 1;
                    }
            }
            Console.WriteLine("Starting coords: " + currentX + ", " + currentY);

            while(true)
            {
                foreach(List<int> c in coords)
                {
                    // Check if the current node is the ending node
                    if (nodes[c[0]][c[1]].type == 2)
                    {
                        break;
                    }

                    bool isLocked = true;
                    if (nodes[c[0] - 1][c[1]].distance == 0)
                    {
                        coords.Add(new List<int>(new int[] { c[0] - 1, c[1], nodes[c[0]][c[1]].distance + 1 }));
                        isLocked = false;
                    }
                    if (nodes[c[0] + 1][c[1]].distance == 0)
                    {
                        coords.Add(new List<int>(new int[] { c[0] + 1, c[1], nodes[c[0]][c[1]].distance + 1 }));
                        isLocked = false;
                    }
                    if (nodes[c[0]][c[1] - 1].distance == 0)
                    {
                        coords.Add(new List<int>(new int[] { c[0], c[1] - 1, nodes[c[0]][c[1]].distance + 1 }));
                        isLocked = false;
                    }
                    if (nodes[c[0]][c[1] + 1].distance == 0)
                    {
                        coords.Add(new List<int>(new int[] { c[0], c[1] + 1, nodes[c[0]][c[1]].distance + 1 }));
                        isLocked = false;
                    }

                    // If the coord has no where else to go, remove it from the list
                    if(isLocked)
                    {
                        coords.Remove(c);
                    }

                    // Remove all duplicates
                    coords = coords.Distinct().ToList();
                }

                
            }
        }
    }
    class Node
    {
        // Type determines if the object is empty (0), a wall (-1), starting node (1), and ending node (2)
        public int type;
        public int distance;
        public Node()
        {
            type = 0;
            distance = 0;
        }
    };
}
