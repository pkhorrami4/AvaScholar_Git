cmake_minimum_required(VERSION 2.6)

SET( 	HEAD_DEMO 
		CRForestEstimator.cpp
		CRTree.cpp
		main.cpp 
)

SET(CMAKE_BUILD_TYPE "Release")

#modify according to your opencv installation
SET( OPENCV_INCLUDES C:\\opencv\\build\\include C:\\opencv\\build\\include\\opencv C:\\opencv\\build\\include\\opencv2) 
SET( OPENCV_LIB C:\\opencv\\build\\x86\\vc10\\lib ) 

INCLUDE_DIRECTORIES( . ${OPENCV_INCLUDES} )
LINK_DIRECTORIES( ${OPENCV_LIB} )

add_executable( head_pose_estimation ${HEAD_DEMO})

target_link_libraries (head_pose_estimation opencv_core241 opencv_highgui241 opencv_imgproc241 )




