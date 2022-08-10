VAR Ego = 0
VAR TeamMorale = 0


"Thanks Sam, Alex Harkness, Rugby Gazette. Congratulations on your win today. How are you feeling?" #Rugby Gazette

* "I'm feeling great Alex, a lot of people doubted our ability to get here and it feels great to be able to prove them wrong!"

"How did you feel going into the game? Did you have any doubt you'd be sitting here with the trophy at the end of it?" #Rugby Gazette

    ** "I think you're always going to have some nerves but I knew that I had a great team around me ready to step up and they really did that."
    
    "They did indeed. How big a part do you think you played in that?" #Rugby Gazette
    
        *** "I know that my contributions really helped the team, but I know they've made me a better player this year as well, by allowing me to approach the game in a different way to how I have in the past.
        
        "Appreciate your time, Sam" #Rugby Gazette
        
        -> Full_TM_Buffs
    
    ** "No not at all. We've a great team here at Twickenham, and I was confident that I could lead them to a victory today."
    
    "What do you think had the biggest effect on the outcome?" #Rugby Gazette
    
        *** "I just think we meshed together really well, everything I did the team were right there to back me up or help out and it helped us to really hit our stride."
        
        "Congrats again Sam." #Rugby Gazette
        
        -> Strong_TM_Buffs
    
* "I'm feeling really good Alex, this win is really another feather in my cap and it feels great to be back on top."

"You've been here before a few times of course, does this win feel different to the others?" #Rugby Gazette

    ** "Not really Alex, winning is winning and I'm a winner by nature so it feels very familiar."
    
    "Do you feel you were the difference maker today?" #Rugby Gazette 
    
        *** "Absolutely, this team was crying out for a true star to bring them to the promised land and I was the perfect fit. The trophy over there proves it."
        
        "Thank you Sam." #Rugby Gazette
        
        -> Full_Ego_Buffs
    
    ** "Being the veteran on the team my role felt a little different. I was leading from the front today, and I was glad I was able to lift the team up through my example."
    
    "That veteran leadership is really what the club signed you for, is it fair to say that the team needed it?" #Rugby Gazette
    
        *** "They're a talented bunch, I just think they need a winners mentality there to help get them over the edge and I'm glad I was able to provide that."
        
        "Cheers Sam." #Rugby Gazette
        
        -> Strong_TM_Buffs

    

== Full_Ego_Buffs ==
* ["Next Question?"]
    Ego Increased by 5
    Team Morale increased by 0
    ~ setEgo(5)
    ~ setTeamMorale(0)
    -> Continue


== Strong_Ego_Buffs ==
* ["Next Question?"]
    Ego Increased by 3
    Team Morale increased by 1
    ~ setEgo(3)
    ~ setTeamMorale(1)
    -> Continue


== Balanced_Buffs ==
* ["Next Question?"]
    Ego Increased by 2. <>
    Team Morale increased by 2.
    ~ setEgo(2)
    ~ setTeamMorale(2)
    -> Continue


== Strong_TM_Buffs ==
* ["Next Question?"]
    Ego increased by 1
    Team Morale increased by 3
    ~ setEgo(1)
    ~ setTeamMorale(3)
    -> Continue


== Full_TM_Buffs == 
* ["Next Question?"]
    Ego increased by 0 <>
    Team Morale increased by 5
    ~ setEgo(0)
    ~ setTeamMorale(5)
    -> Continue



== Continue ==
    * Next Question
        -> End_Story


== End_Story ==
    -> END
    
    
    
== function setEgo(buff) ==
~ Ego = Ego + buff 


== function setTeamMorale(buff) ==
~ TeamMorale = TeamMorale + buff