using System;
using System.Collections.Generic;
 
class MainClass {
 
  public static string HTMLElements(string str) {
 
    if(string.IsNullOrEmpty(str)){
      return "true";
    }
 
    str = str.Trim();
 
    var tags = new List<string>() { "b", "i", "em", "div", "p"};
 
    var listOpenTag = new List<string>();
    var listCloseTag = new List<string>();
    var listOcurrencesOpenTag = new List<int>();
    var listOcurrencesCloseTag = new List<int>();
    var listIndexOfOpenTag = new List<int>();
    var listIndexOfCloseTag = new List<int>();
    var listLastIndexOfOpenTag = new List<int>();
    var listLastIndexOfCloseTag = new List<int>();
 
    foreach(var tag in tags){
      var openTag = string.Format("<{0}>",tag);
      listOpenTag.Add(openTag);
      var closeTag = string.Format("</{0}>",tag);
      listCloseTag.Add(closeTag);
      listOcurrencesOpenTag.Add(0);
      listOcurrencesCloseTag.Add(0);
      listIndexOfOpenTag.Add(str.IndexOf(openTag));
      listLastIndexOfOpenTag.Add(str.LastIndexOf(openTag));
      listIndexOfCloseTag.Add(str.IndexOf(closeTag));
      listLastIndexOfCloseTag.Add(str.LastIndexOf(closeTag));
    }
 
    var badTag = "";
    var firstIndexOf = str.Length;
    var lastIndexOf = -1;
    
    for(var i = 0; i < tags.Count; i++){
 
      listOcurrencesOpenTag[i] = CheckOccurrences(str, listOpenTag[i]);
      listOcurrencesCloseTag[i] = CheckOccurrences(str, listCloseTag[i]);
      
      if(listOcurrencesOpenTag[i] > listOcurrencesCloseTag[i] ) {
          if(listIndexOfOpenTag[i] < firstIndexOf && listIndexOfOpenTag[i] > -1)
          badTag = tags[i];
          firstIndexOf = listIndexOfOpenTag[i];
      }
      else {
        if(string.IsNullOrEmpty(badTag) && listOcurrencesOpenTag[i] < listOcurrencesCloseTag[i]) {
          if(listIndexOfCloseTag[i] > lastIndexOf && listIndexOfCloseTag[i] > -1)
          badTag = tags[i];
          lastIndexOf = listIndexOfCloseTag[i];
        }
      }
 
       
    }
    
    if(string.IsNullOrEmpty(badTag)){
      return "true";
    }
    else{
      return badTag;
    }
 
  }
 
  public static int CheckOccurrences(string str1, string pattern) {
      int count = 0;
      int a = 0;
      while ((a = str1.IndexOf(pattern, a)) != -1) {
         a += pattern.Length;
         count++;
      }
      return count;
   }
 
  static void Main() {  
    // keep this function call here
    Console.WriteLine(HTMLElements(Console.ReadLine()));
  } 
 
}
