VAR Ego = 0
VAR TeamMorale = 0

"Jen Silmaro, The Protector. Commiserations on the loss today. Reports came out this week that the Twickenham medical staff recommended that you be omitted from the squad for today, care to comment?" #The Protector

* "In my experience Doctors are always overly cautious and it didn't really concern me. I passed the protocols, that's all that mattered to me."

"

* "I'm know that the Doc was doing what he thought best, and I listened to his point, but I felt good and I was ready to go."

"

* "I don't think this is the time to discuss private discussions between me and the team doctor. At the end of the day, we have to focus on the result today. We lost and that's where my mind is right now."

"

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