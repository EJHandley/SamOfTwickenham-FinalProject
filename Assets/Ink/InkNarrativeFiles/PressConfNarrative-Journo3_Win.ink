VAR Ego = 0
VAR TeamMorale = 0

"Hi Sam, Jen Silmaro with The Protector. Reports came out this week that Twickenham's team doctor actually recommended you not play today. Why did you make the decision to go ahead with the game?" #The Protector

* "Look, the Doc wanted to be cautious and I understood his reasoning, but I passed the protocols and as far as I was concerned, I wasn't going to miss out on the final."

"Isn't that a bit of a selfish decision to make?" #The Protector

    ** "On the contrary, wanting to help and be there for my team was the major driving force behind me making the decision to play."
    
    "Whilst that's a noble sentiment, surely the team didn't want you to risk more serious injury?" #The Protector
    
        *** "We're a tight knit bunch and the whole team knew I would want to be out there no matter what. They were concerned for me, and I appreciated their concerns, but once I explained to them the importance to me of playing, they got behind me."
        
        "You certainly seem like a close unit. Thanks." #The Protector
        
        -> Full_TM_Buffs
    
    ** "Maybe, but the team were behind me, and I felt like I could play, so why wouldn't I?"
    
    "So you have zero regrets about playing against the advice of Doctors?" #The Protector
    
        *** "Zero. We won, we're champions, and I was so happy to be out there with the team. I know I made the right decision."
        
        "Ok, thank you Sam, Congratulations." #The Protector
        
        -> Strong_TM_Buffs

* "I think the Doc was doing what he thought best but he was wrong. My injury wasn't even that serious, I've suffered far worse." 

"Concussions are a bit of a different beast compared to most injuries though aren't they?" #The Protector

    ** "They said pretty much the same thing but I don't agree. I've torn my ACL before, but I returned to training as soon as I could run on it again, I didn't wait around for it to feel 100%. The principle is the same."
    
    "Just because you can return doesn't always mean you should though does it?" #The Protector
    
        *** "When your the star player on the team and they need you there to win a championship, yeah, it does."
        
        "Ok... thanks." #The Protector
        
        -> Full_Ego_Buffs
    
    ** "Perhaps, but the fact of the matter is that I was allowed to play by the leagues standard. I passed their tests. So why wouldn't I run out on that pitch with the rest of the team?"
    
    "Surely the opinion of your Team doctor should carry some weight in your decision making process?" #The Protector
        
        *** "I made the decision with my own best interests and those of the team in mind, and judging by that trophy over there, it was the right decision."
        
        "Thank you Sam." #The Protector
        
        -> Strong_Ego_Buffs

* "I'd prefer not to comment on internal matters, the Doc's treatment has been exemplary and he, myself and the coaching team made the decision we felt best for me and the team."

"Ok, thanks Sam." #The Protector

-> Balanced_Buffs



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