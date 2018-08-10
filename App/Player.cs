namespace Oregon
{
    public class Player : GameObject
    {
        public double PlayerHealth = 100;
      
        public void Start()
        {
        }

        public void Update()
        {
            this.PlayerHealth -= 0.01;
            if(this.PlayerHealth <= 0)
            {
                //ScreenBuffer.Draw($"DEAD", 0, 15);
            }
            else
            {
                //ScreenBuffer.Draw($"HEALTH: {this.PlayerHealth:###}", 0, 15);
            }
            
            
        }

        public void OnKeyPress()
        {



          
 

        }

     
    }


}

