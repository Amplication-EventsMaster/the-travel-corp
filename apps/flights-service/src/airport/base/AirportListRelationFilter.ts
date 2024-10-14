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
import { AirportWhereInput } from "./AirportWhereInput";
import { ValidateNested, IsOptional } from "class-validator";
import { Type } from "class-transformer";

@InputType()
class AirportListRelationFilter {
  @ApiProperty({
    required: false,
    type: () => AirportWhereInput,
  })
  @ValidateNested()
  @Type(() => AirportWhereInput)
  @IsOptional()
  @Field(() => AirportWhereInput, {
    nullable: true,
  })
  every?: AirportWhereInput;

  @ApiProperty({
    required: false,
    type: () => AirportWhereInput,
  })
  @ValidateNested()
  @Type(() => AirportWhereInput)
  @IsOptional()
  @Field(() => AirportWhereInput, {
    nullable: true,
  })
  some?: AirportWhereInput;

  @ApiProperty({
    required: false,
    type: () => AirportWhereInput,
  })
  @ValidateNested()
  @Type(() => AirportWhereInput)
  @IsOptional()
  @Field(() => AirportWhereInput, {
    nullable: true,
  })
  none?: AirportWhereInput;
}
export { AirportListRelationFilter as AirportListRelationFilter };
