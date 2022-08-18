VAR Ego = 0
VAR TeamMorale = 0

"Thanks Sam, I'm Jo Ansturn with the Evening Banner. Despite the win, there are some that are saying you shouldn't have played and have suggested that even the Head Coach didn't want to start you today, how do you respond?" #Evening Banner

* "I ask anyone who thinks I shoudldn't have been on the pitch to take one look at the result and give me a good reason why."

"The result is of course excellent for the team but it was still a risk your Coach didn't want you to take wasn't it? Isn't that reason enough?" #Evening Banner

    ** "The Gaffer wasn't ever suggesting I wouldn't play, he just had concerns. He quickly came to his senses once he realised I was ready to play and that he needed me out there."
    
    "Clearly you were part of the reason that the team won today, but don't you think the Coach showed a lack of trust in the rest of the team by not allowing you to rest?" #Evening Banner
    
        *** "He was never "allowing me" to play, I'm the first name on that team sheet every time. I wouldn't have "allowed" myself to be on the bench for this game."
        
        "Clearly. Cheers." #Evening Banner
        
        -> Full_Ego_Buffs
    
    ** "It wasn't that he didn't want me to take the risk, it was that he wanted to make sure I was ready to play despite it and I always was."
    
    "Didn't he fail in his job a little though, letting you play despite the injury?" #Evening Banner
    
        *** Not at all. His job his to win Rugby matches, and that's what we did. He's a great coach, and he did the right thing by letting me play."
        
        "There might be some that disagree... thanks Sam." #Evening Banner
        
        -> Strong_Ego_Buffs

* "I'm not sure why people are making such a fuss about this. I played the game, I got through without issue and we won! Me and the team are on cloud 9."

"Well these kinds of injuries are at the forefront of the sport Sam, people might argue that if the coach was looking to bench you despite your form, then you should have been wiser and taken a seat." #Evening Banner

    ** "No one has every used my name alongside the word wise, thats for sure. At the end of the day, the Gaffer was looking out for me, but we talked and he understood my desire to play."
    
    "So he did want to bench you?" #Evening Banner
    
        *** "There was never any mention of benching, but he did want to discuss the risks with me before the game. I understood them and told him I wanted to play and that the team wanted me there too. So he included me."
        
        "That's great, thanks Sam." #Evening Banner
        
        -> Full_TM_Buffs
    
    ** "Wisdom has nothing to do with it. Yes the Coach has some concerns but we talked it out and he made the decision to include me after I put my side forward. There was never any mention of the bench though."

    "Really, even with the concussion?" #Evening Banner
    
        *** "Even then. The team had signed off on it and the Gaffer knows what I bring to the team. He wanted to talk to me about risks but it was never in doubt that he wanted me out there."
        
        "Interesting, thanks Sam." #Evening Banner
        
        -> Strong_TM_Buffs
    
* "I don't think that's relevant right now, we're the league champs and that's what really matters. Me and the Gaffer couldn't be happier with the result."

"Ok Sam, but the fans will want a proper answer to the question at some point." #Evening Banner

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