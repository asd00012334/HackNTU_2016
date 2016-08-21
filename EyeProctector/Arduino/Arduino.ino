#include <LiquidCrystal_I2C.h>


#include <Wire.h> 
#include <PCD8544.h>

#define trig 13
#define echo 12
#define green 2
#define blue 3
#define red 4

float inch = 20;
int level=1;

LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);  

bool moderateDist(float inch, float dist){
  inch = inch*3.81;
  return dist<=10;
}

void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 4);  //1604
  lcd.setCursor(0,0); 
  pinMode(trig,OUTPUT);
  pinMode(green,OUTPUT);
  pinMode(echo,INPUT);
  Serial.begin(9600);  //input to vs
  while(true){
    if(Serial.available()>0){
      inch = atof(&Serial.readString()[0]);
      break;
    }
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  float duration,distance;
  
  digitalWrite(trig,HIGH);
  delayMicroseconds(100);
  digitalWrite(trig,LOW);    //傳High~low會使感測器發出超音波
  duration = pulseIn(echo,HIGH); //接收超音波多久回來
  distance = duration/2/29;     //換成距離

  if(Serial.available()>0){
    String str;
    str=Serial.readString();
    if(str[0]=='r'){      //重設INCH
      lcd.clear();
      lcd.setCursor(0,0);
      while(true){
        if(Serial.available()>0){
          inch = atof(&Serial.readString()[0]);
          break;
        }
      }
    }
    else{
      level = atoi(&str[1]);       //等級提升
    }
  }
  react(inch,distance);
}

void react(float inch, float dist)      //反應距離， 等級
{
  inch = inch*3.81;
  if(inch+15<dist){
    lcd.setCursor(0,0); 
    lcd.print("Too Distant !");
    Serial.print("3\n");
    digitalWrite(green,LOW);
    digitalWrite(red,LOW);
    digitalWrite(blue,HIGH);
  }
  else if (dist<inch-30)
  {
    lcd.setCursor(0,0); 
    lcd.print("Too Close !  ");
    Serial.print("2\n");
    digitalWrite(green,LOW);
    digitalWrite(red,HIGH);
    digitalWrite(blue,LOW);
  }
  else
  {
    lcd.setCursor(0,0); 
    lcd.print("Just right ! ");
    Serial.print("1\n");
    digitalWrite(green,HIGH);
    digitalWrite(red,LOW);
    digitalWrite(blue,LOW);
  }
  

  lcd.setCursor(0,1);
  lcd.print("Eye Pet lv.");
  lcd.print(level);
}
