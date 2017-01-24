// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

/**
 * 
 */
class CAMERA_PATH_API Matrix4
{
private:
  struct matt_vector4 {
    float x;
    float y;
    float z;
    float w;
  };


  matt_vector4 v0_;
  matt_vector4 v1_;
  matt_vector4 v2_;
  matt_vector4 v3_;

  matt_vector4 clear;

public:


  // Construct a Matrix from vectors 
  Matrix4(matt_vector4 v0, matt_vector4 v1, matt_vector4 v2, matt_vector4 v3) {
    v0_ = v0;
    v1_ = v1;
    v2_ = v2;
    v3_ = v3;
  }
  ~Matrix4() {
    v0_ = clear;
    v1_ = clear;
    v2_ = clear;
    v3_ = clear;
  }

  // Matrix * Matrix 
  Matrix4 operator*(const Matrix4& rhs) {
  }

  // Matrixs * Scalar 

  // Matrix / Matrix 

  // Matrix / scalar

  // Matrix - Matrix 


  // Matrix - scalar 

  // Matrix + MAtrix 

  // Matrix + scalar


  // Matrix dot product


  // Matrix cross product 


  // Matrix rotation

  //Matrix translation













};
