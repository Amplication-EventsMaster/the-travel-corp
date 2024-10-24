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
import { FlightWhereUniqueInput } from "../../flight/base/FlightWhereUniqueInput";
import { ValidateNested, IsOptional, IsString } from "class-validator";
import { Type } from "class-transformer";
import { FlightCreateNestedManyWithoutAirlinesInput } from "./FlightCreateNestedManyWithoutAirlinesInput";

@InputType()
class AirlineCreateInput {
  @ApiProperty({
    required: false,
    type: () => FlightWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => FlightWhereUniqueInput)
  @IsOptional()
  @Field(() => FlightWhereUniqueInput, {
    nullable: true,
  })
  arrivalFlights?: FlightWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  country?: string | null;

  @ApiProperty({
    required: false,
    type: () => FlightCreateNestedManyWithoutAirlinesInput,
  })
  @ValidateNested()
  @Type(() => FlightCreateNestedManyWithoutAirlinesInput)
  @IsOptional()
  @Field(() => FlightCreateNestedManyWithoutAirlinesInput, {
    nullable: true,
  })
  flights?: FlightCreateNestedManyWithoutAirlinesInput;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  name?: string | null;
}

export { AirlineCreateInput as AirlineCreateInput };
