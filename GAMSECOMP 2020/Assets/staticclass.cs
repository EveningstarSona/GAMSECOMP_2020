using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class staticclass
{
   static int winorlose = 0;
   public static void setwol(int n){
       winorlose = n;
   }
   public static int getwol(){
       return winorlose;
   }
}
