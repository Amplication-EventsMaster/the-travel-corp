/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { Airline } from "../../airline/base/Airline";
import {
  ValidateNested,
  IsOptional,
  IsDate,
  IsInt,
  IsString,
} from "class-validator";
import { Type } from "class-transformer";
import { Airport } from "../../airport/base/Airport";

@ObjectType()
class Flight {
  @ApiProperty({
    required: false,
    type: () => Airline,
  })
  @ValidateNested()
  @Type(() => Airline)
  @IsOptional()
  airline?: Airline | null;

  @ApiProperty({
    required: false,
    type: () => Airline,
  })
  @ValidateNested()
  @Type(() => Airline)
  @IsOptional()
  arrivalAirport?: Airline | null;

  @ApiProperty({
    required: false,
  })
  @IsDate()
  @Type(() => Date)
  @IsOptional()
  @Field(() => Date, {
    nullable: true,
  })
  arrivalTime!: Date | null;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsInt()
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  availableSeats!: number | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: false,
    type: () => Airport,
  })
  @ValidateNested()
  @Type(() => Airport)
  @IsOptional()
  departureAirport?: Airport | null;

  @ApiProperty({
    required: false,
  })
  @IsDate()
  @Type(() => Date)
  @IsOptional()
  @Field(() => Date, {
    nullable: true,
  })
  departureTime!: Date | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  flightNumber!: string | null;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  updatedAt!: Date;
}

export { Flight as Flight };
