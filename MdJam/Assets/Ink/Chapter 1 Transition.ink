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
c: JE PERDS MON STATUT DE CHERCHEUR !!  {NextScene(3)} {SetFontSize(75)}{TextAlignment(center)}
c: Il ne faut surtout pas que ca arrive. {NextScene(2)} {SetFontSize(40)}{TextAlignment(topLeft)}
s: Bonjour monsieur. {NextScene(4)} {EnterSoignant()}
c: Que ce passe-t-il ?
s: J'ai retrouver vos fiches de patients. Je vais garder les fiches avec moi pour le moment, ils se pourraient que j'en rajoute d'autre.
c: (Me voila rassurer) Merci pour les fiches.
s: De rien. D'ailleurs voici aussi les criteres d'inclusion et d'exclusion pour la recherche.
s: {CritereAppear()}
s: {CritereDisappear()}
c: Merci bien pour ca, je vais tous reverifier.
s: Tres bien, dans ce cas je vais vous laissez, je reviendrais plus tard, j'ai un rendez vous de prevu maintenant.
c: D'accord, a plus tard. {LeaveSoignant()}
c: {SetTransition(0)}
-> Chapter1

===Chapter1===
s:{SetTransition(1)}{NextScene(6)}
s:Bonjour, vous pouvez vous assoir.
s: Alors ? A ce que je vois le traitement standart n'as pas l'air de fonctionner.
m: Malheureusement non...
s: Ne vous inquietez pas Madame. Il s'avere que votre fille est tres probablement eligible a un traitement alternatif.
s: Je vais maintenant vous pauser des question pour savoir si oui on non votre fille est reellement eligible. {NextScene(7)}
->DONE

===Chapter2===

->DONE

===QuestionReponse===

->DONE


===GameOver===
s: Reprennons depuis le debut.
->QuestionReponse

===Chapter3===

->DONE


