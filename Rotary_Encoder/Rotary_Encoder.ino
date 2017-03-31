    /*     Arduino Rotary Encoder Tutorial
     *      
     *  by Dejan Nedelkovski, www.HowToMechatronics.com
     *  
     */
     
     #define outputA 6
     #define outputB 7
     int counter = 0; 
     int aState;
     int aLastState;  
     int buttonState = 0;  

     const int buttonPin = 2; 
     
     void setup() { 
       pinMode (outputA,INPUT);
       pinMode (outputB,INPUT);
       pinMode(buttonPin, INPUT);
       
       Serial.begin (9600);
       // Reads the initial state of the outputA
       aLastState = digitalRead(outputA);   
       digitalWrite(buttonPin, HIGH);
     } 
     void loop() { 

       //Button
       buttonState = digitalRead(buttonPin);
     
       if (buttonState == HIGH)
       {
          Serial.print("B1");
          Serial.println();
          Serial.flush();
          delay(20);
       }
       else{
          Serial.print("B0");
          Serial.println();
          Serial.flush();
          delay(20);
       }

      //Crank
       aState = digitalRead(outputA); // Reads the "current" state of the outputA
       // If the previous and the current state of the outputA are different, that means a Pulse has occured
       if (aState != aLastState){     
         // If the outputB state is different to the outputA state, that means the encoder is rotating clockwise
         if (digitalRead(outputB) != aState) { 
           counter ++;
         } else {
           counter --;
         }
             
          Serial.print("C");
          Serial.println(counter);
          Serial.flush();
          delay(10);
       } 
       aLastState = aState; // Updates the previous state of the outputA with the current state
     }
