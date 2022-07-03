VAR Ego = 0
VAR TeamMorale = 0


"Come in!" #The Gaffer

 * "Hey boss, I was hoping I could talk to you about my injury..." 
 
"Of course Sam, come on in... What's on your mind?" #The Gaffer

    ** "I'm ready to come back boss, I want to play in the final."
    
    "That's not what I heard... Doc says you're not fully healed yet." #The Gaffer
    
        *** "He worries too much... I got through training fine yesterday, ask the coaches."
        
        "When he worries, I worry. This is the biggest game this club has faced for years and I don't want to start a player who won't be able to give 100%" #The Gaffer
        
            **** "What Rugby player ever feels 100%? I've been playing with injuries since I was 23, this is no different."
            
            "It's very different, concussions have to be taken seriously Sam. You've done great things for this team since you singed for us, but I don't know whether beinging you back so soon is what's best." #The Gaffer
            
                ***** "I'm telling you, I can play through it. The moment you think you see my performance drop, you can take me off."
                
                "Fine. I'll give you the start, but the first second you start to struggle, we bring you off." #The Gaffer
                
                    ****** "Absolutely, the last thing I want to do is hold the team back. Thanks for backing me boss."
                    
                    "You've earnt that much from me Sam, don't let me down." #The Gaffer
                    
                    
            
            **** "I get it boss but a minor concussion won't stop me from giving you my best."
            
            "I'm not doubting your work ethic Sam, but every concussion is serious. Are you really sure you can play 80 minutes?" #The Gaffer
            
                ***** "I wouldn't risk it if I wasn't sure, there's no way I could do that to the team. I can do this for them, I'm sure of it."
                
                "Alright Sam, I know the team will feel better having you out there to lead them. Just remember them when you're out there. Any sign of symptoms I want you to let us know." #The Gaffer
                
                    ****** "Of course Gaffer, I swear you'll only get my best. If I'm giving any less that that, I'll take myself off."
                    
                    "I know you will. Report to the training pitch, and make sure you see the Doc again to pass the protocols." #The Gaffer
                    
                    -> Strong_Ego_Buffs
        
        *** "That's not his call, I know my body better than anyone and I'm ready."
        
        "You're right, it's not his call. It's mine. And I trust the word of the Doc, over a player desperate to prove themselves." #The Gaffer
        
            **** "I'm not trying to prove anything, my career speaks for itself. That team can't win this without me!"
            
            "I strongly disagree with that Sam... but it will make it harder for us. Fine, you can play, but your hitting the bench at the first sign of any concussion symptoms." #The Gaffer
            
                ***** "You're making the right decision boss. I've got this."
                
                "You'd better Sam... I've got meetings to attend. We'll talk again soon." #The Gaffer
                
                -> Full_Ego_Buffs
            
            **** "I'm don't mean to question the Doc, but I know myself and I can play. I want to be out there for the team."
            
            "I appreciate that Sam, and I know the team do too. Listen, if you're sure, I'll start you. But the team comes first, and if you're slowing them down, I won't hesitate to pull you out."
            
                ***** "Absolutely, the last thing I want to do is hold the team back. Thanks for backing me boss."
                
                "No problem Sam, I'll have a word with the Doc. Don't let me down." #The Gaffer
                
                -> Balanced_Buffs
    
    ** "Doc doesn't think I'm ready to be back yet... but I want you to put me in the squad for the final."



== Full_Ego_Buffs ==
- Ego Increased by 20
setEgo(20)
- Team Morale increased by 0
setTeamMorale(0)
-> Continue


== Strong_Ego_Buffs ==
- Ego Increased by 15
setEgo(15)
- Team Morale increased by 5
setTeamMorale(5)
-> Continue


== Balanced_Buffs ==
- Ego Increased by 10
setEgo(10)
- Team Morale increased by 10
setTeamMorale(10)
-> Continue


== Strong_TM_Buffs ==
- Ego increased by 5
setEgo(5)
- Team Morale increased by 15
setTeamMorale(15)
-> Continue


== Full_TM_Buffs == 
- Ego increased by 0
setEgo(0)
- Team Morale increased by 20
setTeamMorale(20)
-> Continue


==Continue==
+ Continue
->->


== function setEgo(buff) ==
Ego = Ego + buff 


== function setTeamMorale(buff) ==
TeamMorale = TeamMorale + buff


