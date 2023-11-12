import math
xp = 65
yp= 65

A=[]
a = [[ 290 , 549],[1261 , 572],[ 257, 1530],[1235 ,1533]]

A.append(a[0])
A.append(a[1])
B = []
B.append(a[2])
B.append(a[3])

C = sorted(A, key=lambda point: point[0])
print("sous-liste C", C)
D = sorted(B, key=lambda point: point[0])
print("sous-liste D", D)

liste_finale = []
liste_finale = C+D
print(liste_finale)

x1 = abs((liste_finale[0][0]-liste_finale[1][0]))
print(x1)
x2 = abs((liste_finale[2][0]-liste_finale[3][0]))
print(x2)
y1 = abs((liste_finale[0][1]-liste_finale[2][1]))
print(y1)
y2 = abs((liste_finale[1][1]-liste_finale[3][1]))
print(y2)

moy1 = (x1+x2)/2
moy2 = (y1+y2)/2

print("moy x:", moy1, "moy y:", moy2)




#######

E = []
e = [[ 71,253],[1105,334],[ 1067,1318],[44,1336]]

E.append(e[0])
E.append(e[1])
print("E",E)
F = []
F.append(e[2])
F.append(e[3])
print("F",F)
G = sorted(E, key=lambda point: point[0])
print("sous-liste G", G)
H = sorted(F, key=lambda point: point[0])
print("sous-liste H", H)

liste_finale2 = []
liste_finale2 = G+H
print(liste_finale2)

X1 = abs((liste_finale2[0][0]-liste_finale2[1][0]))
print(X1)
X2 = abs((liste_finale2[2][0]-liste_finale2[3][0]))
print(X2)
Y1 = abs((liste_finale2[0][1]-liste_finale2[2][1]))
print(Y1)
Y2 = abs((liste_finale2[1][1]-liste_finale2[3][1]))
print(Y2)

moy11 = (X1+X2)/2
moy22 = (Y1+Y2)/2

print("moy X:", moy11, "moy Y:", moy22)

tailleBoxx = (xp*moy11)/moy1
tailleBoxy = (yp*moy22)/moy2

print("L'objet fait", tailleBoxx, "mm par", tailleBoxy, "mm")



