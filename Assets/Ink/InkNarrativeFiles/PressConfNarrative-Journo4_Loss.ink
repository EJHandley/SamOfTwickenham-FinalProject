VAR Ego = 0
VAR TeamMorale = 0

"Hi Sam, Jo Ansturn, Evening Banner. Following the loss today, we're hearing suggestions that the Head Coach didn't want to play you due to your injury, care to comment?" #Evening Banner

* "The Gaffer and I made a decision together that I would play today, and it was the right one. I was 100% ready and I'll defy anyone to suggest that I didn't give my all."

"It seems like it just wasn't enough though today, so do you think in hindsight it would have been better for you to stay away from the first team?" #Evening Banner

    ** "No. I'm an integral part of the squad, when we need those flashes of inspiration, I'm the one that they look to. I couldn't sit this one out."
    
    "So the Coach let you play because the team couldn't do it without you?" #Evening Banner
    
        *** "Essentially yes. Their a good bunch but you need a star player, a cutting edge in these sorts of games and that's what I bring."
        
        "Ok... thanks Sam." #Evening Banner
        
        -> Full_Ego_Buffs
    
    ** "You'd have to ask the rest of the team that question, but personally, I felt fit and I was raring to go. I don't think I let myself or the team down today."
    
    "I wasn't meaning to suggest that Sam, but won't there always be a question around this loss now, about what would have been different if you'd made a different choice?" #Evening Banner
    
        *** "What ifs are for the fans, I don't really deal in them. I played my best but couldn't get us over the line. End of story."
        
        "Comisserations Sam." #Evening Banner
        
        -> Strong_Ego_Buffs

* "Me and Coach talked it out and we made the decision to include me in the game. We agreed that if I was affecting the team I would come straight off and he didn't sub me so I must have done OK."

"Even if you didn't have a negative impact on the team, do you think you perhaps failed to have the positive impact you usually would because of the injury?" #Evening Banner

    ** "We're a close knit team, and that leads to a certain level of mutual respect and honesty. I like to think the lads would have told me if they felt I was dropping the ball, so to speak."
    
    "So you think this was the correct decision? You don't think it, combined with the loss, could cause ownership to look at the Coaches position?" #Evening Banner
    
        *** "It certainly shouldn't, he's done a great job and I know the team is better for having him here."
        
        "Thanks Sam." #Evening Banner
        
        -> Full_TM_Buffs
    
    ** "Perhaps, but I feel like I did all that I could for the team, and when I was out there it certainly seemed like everyone else did too."
    
    "Was coaching the issue?" #Evening Banner
    
        *** "Maybe, he made the right decisions throughout this process, but perhaps his hesitation with some his decisions had an effect, I don't know."
        
        "Ok thanks." #Evening Banner
        
        -> Strong_TM_Buffs

* "No, I really don't care to comment to be honest."

"Understood, Sam." #Evening Banner



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