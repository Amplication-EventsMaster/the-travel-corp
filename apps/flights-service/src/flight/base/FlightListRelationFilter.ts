/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { FlightWhereInput } from "./FlightWhereInput";
import { ValidateNested, IsOptional } from "class-validator";
import { Type } from "class-transformer";

@InputType()
class FlightListRelationFilter {
  @ApiProperty({
    required: false,
    type: () => FlightWhereInput,
  })
  @ValidateNested()
  @Type(() => FlightWhereInput)
  @IsOptional()
  @Field(() => FlightWhereInput, {
    nullable: true,
  })
  every?: FlightWhereInput;

  @ApiProperty({
    required: false,
    type: () => FlightWhereInput,
  })
  @ValidateNested()
  @Type(() => FlightWhereInput)
  @IsOptional()
  @Field(() => FlightWhereInput, {
    nullable: true,
  })
  some?: FlightWhereInput;

  @ApiProperty({
    required: false,
    type: () => FlightWhereInput,
  })
  @ValidateNested()
  @Type(() => FlightWhereInput)
  @IsOptional()
  @Field(() => FlightWhereInput, {
    nullable: true,
  })
  none?: FlightWhereInput;
}
export { FlightListRelationFilter as FlightListRelationFilter };