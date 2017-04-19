using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace GenericHid
    {
        class WSUser
        {
            public string Name;
            public int age;
            public DateTime birthdate;
            public int ID;
        }


        public class WSRegistry
        {
            public int userID;
            public DateTime fecha;
            public float weightKG;
            public float boneKG;
            public float fat;
            public float water;
            public float Muscle;

            public void clear()
            {
                //fecha = null;
                weightKG = 0;
                boneKG = 0;
                fat = 0;
                water = 0;
                Muscle = 0;
            }
        }



        public class reader
        {
            private WSUser currentUser;
            private int currentProcess;
            private int currentPart;
            private int currentRegistry;
            private int currentRegistryFound;
        }
    }
