using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomsSymulator
{
    class StateManager
    {
        public List<State> states;


        public StateManager()
        {
            states = new List<State>();
        }

        public State GetState(int index)
        {
            return states[index];
        }

        public void AddState(State s)
        {
            states.Add(s);
        }
    }
}
