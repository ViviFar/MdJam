# author: Diaz Teo
# title: The Hospital

EXTERNAL EnterSoignant()
EXTERNAL LeaveSoignant()
EXTERNAL SetFontSize(size)
EXTERNAL TextAlignment(size)
EXTERNAL SoignantExitToNextChapter()
EXTERNAL NextScene(scene)
EXTERNAL CritereAppear()
EXTERNAL CritereDisappear()
EXTERNAL SetTransition(transition)
VAR center = 514
VAR topLeft = 257
VAR fail =0
-> Prologue

===Info===
n: Je suis le narrateur.
f: Je suis la petite fille.
m: Je suis la maman.
c: Je suis le chercheur.
s: Je suis le soignant.
->END

===Prologue===
c: ... {SetFontSize(40)}{TextAlignment(topLeft)}
c: Bon !
c: Il faut que je retrouve ces fiches de patients.
c: Sans ca, pas d'etude et donc {NextScene(2)}
c: JE PERDS MON STATUT DE CHERCHEUR !!  {NextScene(3)} {SetFontSize(70)}{TextAlignment(center)}
c: Il ne faut surtout pas que ca arrive. {NextScene(2)} {SetFontSize(40)}{TextAlignment(topLeft)}
s: Bonjour monsieur. {NextScene(4)} {EnterSoignant()}
c: Que ce passe-t-il ?
s: J'ai retrouver vos fiches de patients. Je vous les mets ici, il se pourraient que d'autre arrive dans la journee donc attendez un peu avant commencer a trier.
c: (Me voila rassurer) Merci pour les fiches.
s: De rien. D'ailleurs voici aussi les criteres d'inclusion et d'exclusion pour la recherche.
s: {CritereAppear()}
s: {CritereDisappear()}
c: Merci bien pour ca, je vais tous reverifier.
s: Tres bien, dans ce cas je vais vous laissez, je reviendrais plus tard, j'ai un rendez vous de prevu maintenant.
c: D'accord, a plus tard.
c: {SetTransition(0)}
-> Chapter1

===Chapter1===
s:{SetTransition(1)}{NextScene(6)}
s: Bonjour, vous pouvez vous assoir.
s: Alors ? A ce que je vois le traitement standart n'as pas l'air de fonctionner.
m: Malheureusement non...
s: Ne vous inquietez pas Madame. Il s'avere que votre fille est tres probablement eligible a un traitement alternatif.
s: Je vais maintenant vous pauser des question pour savoir si oui on non votre fille est reellement eligible. {NextScene(7)}
s: Certaine question vont sans doute vous semblez stupide au vu de l'age de votre fille mais elles sont necessaire.
->Question1

->DONE

===Chapter2===
c:{SetTransition(1)}{NextScene(9)}
c: Bon, il est temps de trier.
c: {NextScene(10)}
->DONE

===Question1===
s: Comment ce passe le traitement actuelle ?
+   Plutot bien -> Question1Answer1
+   Non -> Question1Answer2
+   [...] -> Question1Answer3
*->DONE

===Question1Answer1===
m: Oui bien evidemment.
s: Tres bien
->Question2

===Question1Answer2===
m: Non, je ne lui est donne aucun autre medicaments en dehors de ceux du traitement initial.
s: Interressant
->Question2


===Question1Answer3===
m: ... [{~fail = fail + 1}]
s: Le silence n'est pas une reponse mais soit.
->Question2

===Question2===
s: Votre fille est-elle atteinte du symdrome du VIH ?
+ [Oui] -> Question2Answer1
+ [Non] -> Question2Answer2
+ [...] -> Question2Answer3
-> DONE


===Question2Answer1===
s: D'accord.
->CheckQuestion
->DONE  

===Question2Answer2===
s: Je vois.
->CheckQuestion
->DONE


===Question2Answer3===
s:...    [{~fail = fail + 1}]
->CheckQuestion
->DONE


===CheckQuestion===
{
    - fail == 2: 
        -> GameOver
    - else:    
        s: D'apres les resultats votre fille est bien eligible.
        s: Voulez vous faire le traitement alternatif ?
        m : Oui !
        s : Tres bien, je vous recontacterais d'ici peu, Encore merci et a bientot.
        s: {SetTransition(0)}
        ->Chapter2
}
->DONE

===GameOver===
s: J'ai l'impression que quelque erreurs se sont mis dans les questions...
s: Reprennons depuis le debut.
->Question1

===Chapter3===

->DONE


