#include "console_lib.h"

int Length(char *arr) {
	int i = 0;
	for(int j = 0; arr[j] != '\0';j++){
		i++;
	}

	return i;
}

void SyntaxError(string filename){
	char str[100];
	char buffer[100];
	int j = 0;
	int counter = 1;
	int kal = 0;
	int k = 0;
	char value[] = {'(', '{', '[', ')', '}', ']'};

	FILE *fp;
	char arr[100];

	strcpy(arr, filename.c_str());

	fp = fopen(arr, "r");

		while(fgets(buffer, 100, fp)){
			kal++;
			 //std::cout << Length(buffer) << std::endl;
			for(int i = 0; i < Length(buffer); i++)
			{
			  if(buffer[i] == '{' || buffer[i] == '}' || buffer[i] == '[' || buffer[i] == ']' || buffer[i] == '(' || buffer[i] == ')')
			  {
					str[j] = buffer[i];
					str[j + 1] = kal + 48;
					j += 2;
				  //	std::cout << str << std::endl;
			  }
			}
		}

		str[j] = 0;

		for(int i = 0; i < Length(str); i++){
		  for(int k = 0; k < 3; k++){
			if(str[i] == value[k])
			{
				for(int j = i + 1; j < Length(str); j++){
					if(str[j] == value[k + 3]){
						counter--;
					}

					if(str[j] == value[k]){
						counter++;
					}
				}

				if(counter != 0)
				{
					//char a = str[i++];
					printf("Syntax Error ");
					putchar(str[++i]);
					printf(" colow\n");
					break;
				}
			}
			counter = 1;
          }
		}
	fclose(fp);
}