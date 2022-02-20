using System;

namespace BorderControl
{
    public class Robot : IId
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Name
        {
            get => this.model;
            private set
            {
                this.model = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                this.id = value;
            }
        }
    }
}
