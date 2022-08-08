VAR Ego = 0
VAR TeamMorale = 0


"Steve Thompson, The Daily Kick. Well done today. There was some concern entering the match today about the concussion you suffered in the semi-final, how did you feel out there?" #The Daily Kick

* "Absolutely fantastic, I never doubted I could do a job today despite the injury and I think I proved myself today."

"You did indeed. Are you glad that you risked it?" #The Daily Kick

    ** "Of course. As I said, it was never a risk to me, I was always going to play, and it's a good thing I did!"
    
    "A good thing?" #The Daily Kick
    
        *** "We won didn't we? Would we if I hadnt been able to play? I'm not so sure. The lads needed me there to lead them to the victory."
        
        "Ok, thanks." #The Daily Kick
        
        -> Full_Ego_Buffs
    
    ** "It was only ever a minor risk as far as I'm concerned. I never let it stop me from contributing to the win today." 
    
    "And you were happy with your contributions?" #The Daily Kick
    
        *** "Yeah, very happy. The team really got behind me and that gave me the confidence I needed to dominate in the way I knew I could."
        
        "Cheers Sam." #The Daily Kick
        
        -> Strong_Ego_Buffs

* "I can't say there weren't a few effects but I was always confident I could play and the team really backed me which felt great."

"In hindsight, do you think you should have played it safe?" #The Daily Kick

    ** "No not at all, as I said the whole club was behind me and they really stepped up to support me."
    
    "Should they have had to support you though?" #The Daily Kick
    
        *** "I'm confident that I wasn't a detriment to the team and the result supports that. I think they were glad to have me out there and I was happy to be out there with them."
        
        "Ok, cheers Sam." #The Daily Kick
        
        -> Strong_TM_Buffs
    
    ** "Maybe, but the result speaks for itself. We won today and I hope that my presence on the pitch was a big part of that. The team played great and I hope that I helped lead them to the victory."
    
    "So you think if the injury had forced you to sit the game, the team would have struggled?" #The Daily Kick
    
        *** "No not at all, we have an excellent team with lots of talent. I just wanted to be able to help the team win and I think I was able to do that."
        
        "sure, thanks Sam." #The Daily Kick
        
        -> Full_TM_Buffs
    


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

