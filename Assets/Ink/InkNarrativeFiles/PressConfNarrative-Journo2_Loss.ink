VAR Ego = 0
VAR TeamMorale = 0


"Steve Thompson, The Daily Kick. A hard loss today for your team and it has a lot of people asking the same question. Do you think you should have played today after suffering the concussions during the semi-final?" #Daily Kick

* "Of course I do, I have no doubt that I made the right decision. My contributions weren't the issuse today."

"What do you think were the issues Sam?" #Daily Kick

    ** "Even carrying an injury I felt that I was having to lead the way today. I'm not sure some of my teammates wanted it as much as I did."
    
    "So you think the effort levels were the issue? Could the team have expended a little too much energy having to cover for you?" #Daily Kick
    
        *** "Don't be ridiculous, I was still leading the way out there despite my minor bump to the head. We may have lost with me on the pitch, but we would have been slaughtered if I wasn't."
        
        "Slaughtered... ok, thanks" #Daily Kick
        
        -> Full_Ego_Buffs
    
    ** "Everyone gave their best effort but at the end of the day the execution just wasn't there. We had too many chances go missing."
    
    "You missed a few yourself Sam, can you say with 100% certainty that the concussion didn't have an effect today?" #Daily Kick
    
        *** "Nothings 100%, but I know myself and I gave my all. I don't think I could have given more even without the bump to the head. If my team doesn't feel it was enough, that'll be a tough pill to swallow for me, but you'll have to ask them that questions."
        
        "I will do, thanks Sam." #Daily Kick
        
        -> Strong_Ego_Buffs
    
* "I truly believed going into the game that I was read for the match and I still believe I played as well as I could have, injury or not. I would never have risked it if the team weren't in support."

"It's great that the team gave you their backing, but do you think it was right to put them in a position where they may have felt they had to?" #Daily Kick

    ** "Not one time did I ask them to come out publicly and say they wanted me out there. I talked with team privately, and they gave me their support."
    
    "Would any of them gone against the veteran superstar of the team though?" #Daily Kick
    
        *** "That team aren't pushovers, their talented professional to a man and they would have had no problem telling me the truth if they felt I needed to hear it, believe you me."
        
        "Understood, thanks." #Daily Kick
        
        -> Strong_TM_Buffs
    
    ** "I wasn't looking for justification. If they had told me they thought I should sit on the bench for this one, I would have."
    
    "A final on the line, and you would have have acquiesced to your teammates if they'd told you not to play?" #Daily Kick
        
        *** "Absolutely, Rugby is a team sport and if they had felt I would be a detriment to them I never would have laced up my boots. But they wanted me out there with them and I'm glad I was, win or lose."
            
        "Ok, thanks Sam" #Daily Kick

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

