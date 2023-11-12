import cv2
import numpy as np
import utilis

webcam = False
path = '1.jpg'
path2= '2.jpg'
cap = cv2.VideoCapture(1)
cap.set(10,160)
cap.set(3,1920)
cap.set(4,1080)
scale = 3
wB = 300 * scale
hB = 300 * scale
w = 60
h = 60


while True:
    if webcam: success,img = cap.read()
    else:
        img = cv2.imread(path)
        img2 = cv2.imread(path2)

    img,conts = utilis.Cont(img)

    #img2,conts = utilis.Cont(img2)
    #print(conts)
    #print()

    if len(conts) != 0:
        biggest = conts[0][2]
        #print("Biggest",biggest)
        imgWarp = utilis.warpImg(img, biggest, wB, hB)
        #imgWarp = utilis.warpImg(img2, biggest, w, h)
        cv2.imshow('Warpimg',imgWarp)
       # nPoints = utilis.reorder(points)
        #utilis.findDis([0][0]//scale, [1][1]//scale)

    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow('Original',img)
    cv2.waitKey(0)
    break