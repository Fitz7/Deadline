// Fill out your copyright notice in the Description page of Project Settings.

#include "Deadline.h"
#include "CorruptionSpread.h"
#include "CorruptionBlock.h"

ACorruptionSpread::ACorruptionSpread( const class FPostConstructInitializeProperties& PCIP )
	: Super( PCIP )
{
	testRoot = PCIP.CreateDefaultSubobject< USceneComponent >( this, TEXT( "Dummy0" ) );
	RootComponent = testRoot;
	blockSpacing = 300.0f;
	size = 3;
}

void ACorruptionSpread::BeginPlay( )
{
	Super::BeginPlay( );
	const int32 numberOfBlocks = size * size;

	ACorruptionBlock* newBlock = GetWorld( )->SpawnActor< ACorruptionBlock >( FVector( 1, 1, 1 ), FRotator( 0, 0, 0 ) );

	//for ( int32 blockIndex = 0; blockIndex < numberOfBlocks; blockIndex++ )
	//{
	//	const float xOffSet = ( blockIndex / size ) * blockSpacing;
	//	const float yOffSet = ( blockIndex % size ) * blockSpacing;

	//	const FVector blockLocation = FVector( xOffSet, yOffSet, 0.0f ) + GetActorLocation( );
	//	
	//
	//}
}