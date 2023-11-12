import cv2
import numpy
import numpy as np


def getContours(img,cThr=[50,50],showCanny=False, minArea=1000,filter=0, draw=False):
    imgGray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
    #imgGray = img
    imgBlur = cv2.GaussianBlur(imgGray,(5,5),1)
    imgCanny = cv2.Canny(imgBlur,cThr[0],cThr[1])
    kernel = np.ones((5,5))
    imgDial = cv2.dilate(imgCanny,kernel,iterations=3)
    imgThre = cv2.erode(imgDial,kernel,iterations=2)
    if showCanny: cv2.imshow('Canny',imgThre)

    contours,hiearchy = cv2.findContours(imgThre,cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
    finalContours = []
    for i in contours:
        area = cv2.contourArea(i)
        if area > minArea:
            peri = cv2.arcLength(i,True)
            approx = cv2.approxPolyDP(i,0.02*peri,True)
            bbox = cv2.boundingRect(approx)
            if filter > 0:
                if len(approx) == filter:
                    finalContours.append([len(approx),area,approx,bbox,i])
            else:
                finalContours.append([len(approx),area,approx,bbox,i])

    finalContours = sorted(finalContours,key = lambda x:x[1],reverse=True)
    #print("1&",finalContours)
    if draw:
        for con in finalContours:
            cv2.drawContours(img, con[4],-1 ,(0,0,255),3)


    return (img , finalContours)







def Cont(I0):

    I = cv2.cvtColor(I0, cv2.COLOR_BGR2GRAY)
    N = []
    for i in range(np.shape(I)[0]):
         M=[]
         for j in range (np.shape(I)[1]):
             M.append(0)
             if I[i][j] < 140:
                 M[j]=255
         N.append(M)
    N=np.asarray(N, dtype=numpy.uint8)

    cv2.imshow('Black',N)
    N = np.stack((N,N, N), axis=-1)

    J = cv2.imread('2.jpg')
    cv2.imshow('Blue1',J)
    #print("JJJJJ",J)
    J = cv2.resize(J, (0, 0), None, 0.5, 0.5)
    B = []
    for i in range(np.shape(J)[0]):
        b = []
        for j in range(np.shape(J)[1]):
            b.append(0)
            if J[i][j][2] < 100:
                b[j] = 255
        B.append(b)
    #print(B)
    B = np.asarray(B, dtype=numpy.uint8)

    cv2.imshow('Blue', B)
    B = np.stack((B, B, B), axis=-1)

    img, finalContours = getContours(B, showCanny=True, draw=True)

    img1,finalContours = getContours(N,showCanny=True, draw = True)
#####


####

    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow('Original',img)

    return (img, finalContours)

def reorder(myPoints):
    #print(myPoints.shape)
    myPointsNew = np.zeros_like(myPoints)
    myPoints = myPoints.reshape((4,2))
    add = myPoints.sum(1)
    myPointsNew[0] = myPoints[np.argmin(add)]
    myPointsNew[3] = myPoints[np.argmax(add)]
    diff = np.diff(myPoints, axis=1)
    myPointsNew[1] = myPoints[np.argmin(diff)]
    myPointsNew[2] = myPoints[np.argmax(diff)]
    return myPointsNew

def warpImg (img,points,w,h,pad=20):
    #print("points",points)
    points = reorder(points)
    print("points", points)

    #pts1 = np.asarray(points, dtype=numpy.uint8)
    #pts2 = np.asarray([[0,0],[w,0],[0,h],[w,h]], dtype=numpy.uint8)
    pts1 = np.float32(points)
    pts2 = np.float32([[0,0],[w,0],[0,h],[w,h]])
    matrix = cv2.getPerspectiveTransform(pts1,pts2)
    imgWarp = cv2.warpPerspective(img,matrix,(w,h))
    imgWarp= imgWarp[pad:imgWarp.shape[0]-pad,pad:imgWarp.shape[1]-pad]

    return imgWarp

#def findDis(pts1,pts2):
    #return ((pts2[0]-pts1[0])**2 + (pts2[1]-pts1[1])**2)**0.5
    A = []
    a = sorted(points, key=lambda point: point[1])
    print("liste triée selon y", a)
    A.append(a[0],a[1])
    B = []
    B.append(a[2], a[3])

    C= sorted(A, key=lambda point: point[0])
    print("sous-liste C", C)
    D = sorted(B, key=lambda point: point[0])
    print("sous-liste D", D)

    liste_finale = []
    liste_finale = C+D
    print(liste_finale)

    x1 = (liste_finale[0]-liste_finale[1])
    distancex1 = liste_finale[1]

    x2 = (liste_finale[2] - liste_finale[3])
    distancex2 = liste_finale[1]

    y1 = (liste_finale[0] - liste_finale[2])
    distancex1 = liste_finale[1]

    y2 = (liste_finale[1] - liste_finale[3])
    distancex2 = liste_finale[1]

    moy1 = sum(distancex1+distancex2)/2
    moy2 = sum(liste_finale[2]+liste_finale[3])/2

    print("moy1",moy1,"moy2",moy2)




