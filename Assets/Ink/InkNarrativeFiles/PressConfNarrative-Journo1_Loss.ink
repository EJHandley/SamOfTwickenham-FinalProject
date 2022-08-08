VAR Ego = 0
VAR TeamMorale = 0


"Thanks Sam, Alex Harkness, Rugby Gazette. Tough loss today, it was a real nailbiter but you just couldn't hold on. How are you feeling?" #Rugby Gazette

* "I've felt better Alex. I'm gutted that we weren't able to pull out the win tonight, especially for the fans who came down to see us."

"I know coming into this season you were heavy favourites to win the title, how does it feel to fall short?" #Rugby Gazette

    ** "It's really tough, to know we had all the talent and ability to win that game but to fail anyway, it's heartbreaking."
    
    "Do you think you should have seen more of the ball during the game?" #Rugby Gazette
    
        *** "Rugby is a team sport. No one player loses a game, at the end of the day, we just didn't have what it takes and that hurts. We've got to look forward to next year now."
        
        "Comisserations Sam." #Rugby Gazette
        
        -> Full_TM_Buffs
    
    ** "I can't say it isn't painful. I know that we could have won that game so to fall short is devastating. We obviously just didn't want it as much as they did."
    
    "When you look back on the match, is there anything you could have done to change things?" #Rugby Gazette
    
        *** "It's too early to be thinking about that just yet. At the end of the day we could have pulled out a win today, but we didn't and thats something the whole team will have to live with."
        
        "Good effort Sam." #Rugby Gazette
        
        -> Strong_TM_Buffs
    
* "I'm angry Alex. We should have won that game. We had all the chances in the world but the team just couldn't seem to finish them off.

"What do you think was the biggest contributing factor to the loss?" #Rugby Gazette

    ** "Our overall team performance just wasn't there. I gave my all today but maybe I didn't do a good enough job of getting other players involved."
    
    "Do you have any regrets now as you look back on the game?" #Rugby Gazette
    
        *** "I think it's a little early to start analysising but ultimately, I just wish I could have gotten us to the level we needed in order to win."
        
        "Cheers Sam." #Rugby Gazette
        
        -> Strong_Ego_Buffs
    
    ** "I think some of the team just let us down in the end. I can make all the great plays in the world but if my team mates aren't backing me up, it's only gonna end one way."
    
    "So you're happy that you gave your all today?" #Rugby Gazette
    
        *** "Absolutely, I left everything out on the field. If anything, I wish I had kept the ball to myself a few times. Maybe I could have gotten us over the line."
        
        "Alright, thanks Sam." #Rugby Gazette
        
        -> Full_Ego_Buffs
    



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