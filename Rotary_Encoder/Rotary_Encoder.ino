    /*
     * This code was based originally of the 'Arduino Rotary Encoder Tutorial' by Dejan Nedelkovski, www.HowToMechatronics.com
     * The button and analog stick was
     */
     
     int outputA = 6;
     int outputB = 7;
     int counter = 0; 
     int curCrankState = 0;
     int prevCrankState = 0;  
     
     int buttonVal = 0;  
     int analogVerVal = 0;
     int analogHorVal = 0;
     
     const int analogVerPin = 1;
     const int analogHorPin = 2;
     const int buttonPin = 2; 
     
     void setup() 
     { 
       pinMode (outputA,INPUT);
       pinMode (outputB,INPUT);
       pinMode(buttonPin, INPUT);
       
       Serial.begin (9600);
       prevCrankState = digitalRead(outputA);   
       digitalWrite(buttonPin, HIGH);
     } 
     void loop() 
     { 
       //Analog stick
       analogVerVal = analogRead(analogVerPin);
       delay(100);  
       analogHorVal = analogRead(analogHorPin);
       Serial.print("H"); //H tags it for horizontal input
       Serial.println(analogHorVal);

       Serial.print("V"); //V tags it for vertical input
       Serial.println(analogVerVal);
       delay(1);

       //Button
       buttonVal = digitalRead(buttonPin);
     
       if (buttonVal == HIGH)
       {
          Serial.print("B1"); //B tags it for button input
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
       curCrankState = digitalRead(outputA);
       if (curCrankState != prevCrankState)
       {     
         if (digitalRead(outputB) != curCrankState) 
         { 
           counter ++;
         } 
         else 
         {
           counter --;
         }            
          Serial.print("C"); //C tags it for crank input
          Serial.println(counter);
          Serial.flush();
          delay(10);
       } 
       prevCrankState = curCrankState; 
     }
