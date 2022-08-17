VAR Ego = 0
VAR TeamMorale = 0

"Jen Silmaro, The Protector. Commiserations on the loss today. Reports came out this week that the Twickenham medical staff recommended that you be omitted from the squad for today, care to comment?" #The Protector

* "In my experience Doctors are always overly cautious and it didn't really concern me. I passed the protocols, that's all that mattered to me." 

"Whilst thats understandable, didn't the fact that it was your club doctor recommending that you not play come into consideration at all?" #The Protector

    ** "Honestly, no. I've been playing Rugby for 15 years, I know what I'm about. This whole injury business is being completely blown out of proportion." 
    
    "With the spate of former Rugby players being diagnosed with issues such as early onset dementia, some might say you're taking this too lightly?" #The Protector
    
        *** "What others think isn't important to me. I have sympathy for all the former players that are suffering now, but this was one concussion."
        
        "Ok, thanks Sam." #The Protector
        
        -> Full_Ego_Buffs
    
    ** "Maybe a little, but as I said, I was never as concerned as everyone else seemed to be, and as it's my body, surely that's all that matters?"
    
    "A lot of players are suffering from debilitating conditions in the wake of their careers due to these very injuries, was that not on your mind?" #The Protector
    
        *** "Of course, I think it's on the mind of every player, but the League has responded and put measures in place to try and mitigate these issues. I passed their tests and was cleared to play. It's as simple as that."
        
        "Thanks Sam." #The Protector
        
        -> Strong_Ego_Buffs

* "I'm know that the Doc was doing what he thought best, and I listened to his points, but I felt good and I was ready to go."

"Do you think the team felt as confident about you playing as you did?" #The Protector

    ** "Absolutely, I took them all aside for a players meeting and told them I wanted to play, and they were all behind me 100%."
    
    "So you don't think there will be any recriminations from the team after the loss? Any suggestion that perhaps you shouldn't have played?" #The Protector
    
        *** "Not at all. We all have to look at ourselves in the wake of the result but their a great bunch of lads and I know they'll support me just as I'll support them."
        
        "That's good to hear, thanks Sam." #The Protector
        
        -> Full_TM_Buffs
        
    ** "Yeah of course I mentioned it to them, it was only right considering I was going to insist on being in the starting lineup. They didn't have any objections, they knew that I needed to be out there and that they needed me out there too."
    
    "Do you think they may have felt like they had to defer to you as the senior member of the team?" #The Protector
    
        *** "No, I don't think so. They know they can always be honest with me as I'm honest with them. I just think they saw that the benefits of having me out there were worth the risk."
        
        "Interesting, Ok, thanks Sam." #The Protector
        
        -> Strong_TM_Buffs

* "I don't think this is the time to discuss private discussions between me and the team doctor. At the end of the day, we have to focus on the result today. We lost and that's where my mind is right now."

"I understand, thanks Sam." #The Protector

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